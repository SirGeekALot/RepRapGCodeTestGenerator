using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RepRapGCodeTestGenerator
{
    public partial class Form1 : Form
    {
        // Class variables

        // Init to most common defaults before calling TryParse on user entered data, then just use these values if TryParse fails.
        double gdblXMin = 0;
        double gdblYMin = 0;
        double gdblXMax = 200;
        double gdblYMax = 200;
        double gdblCircleSegmentCount = 5;

        // F command is feedrate in millimeters per minute, so multiply millimeters/second by 60.
        int gintTravelSpeedmms = 200;

        // carriage return + line feed
        string crlf = Environment.NewLine; 

        public Form1()
        {
            InitializeComponent();
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string filePath = desktopPath + "\\BreakInGCode.gcode";
            txtFileName.Text = filePath;
        }

        private void btnCreateFile_Click(object sender, EventArgs e)
        {
            string strOutputFile = txtFileName.Text;
            double dblRepeatMax = 1; // Only do it once if the textbox has an invalid value.
            bool ignore = false;  // Ignore the parse results for now; just use pre-initialized values if the user enters something invalid.

            // Get the user-defined numerical values.  Silently use defaults on user entry error.
            ignore = double.TryParse(txtXMin.Text, out gdblXMin);
            ignore = double.TryParse(txtXMax.Text, out gdblXMax);
            ignore = double.TryParse(txtYMin.Text, out gdblYMin);
            ignore = double.TryParse(txtYMax.Text, out gdblYMax);
            ignore = double.TryParse(txtRepeats.Text, out dblRepeatMax);
            ignore = double.TryParse(txtCircleSegmentCount.Text, out gdblCircleSegmentCount);

            // Get the user-defined speed.
            ignore = int.TryParse(txtSpeed.Text, out gintTravelSpeedmms); // Ignore result and use the global print speed setting if the parse fails.

            // Create header
            string strGCode =
                "G28\t\t; home all axes" + crlf +
                "G90\t\t; use absolute positioning" + crlf +
                "G21\t\t; use metric values" + crlf +
                GotoPositionXY(gdblXMin, gdblYMin, "move X/Y to min endstops") +
                //"G28 Z0\t\t; move Z to min endstops" + crlf +
                "G1 Z8.0 F600\t; move the platform down 8mm at 10mm/s" + crlf;

            // Loop through the all g-code generation features until done.
            for (int idx = 1; idx <= dblRepeatMax; idx++)
            {
                strGCode += crlf;
                strGCode += ";========== Begin Loop # " + idx.ToString() + " ==========" + crlf;
                strGCode += GenerateGCode();
                strGCode += ";========== End Loop # " + idx.ToString() + " ==========" + crlf;
            }

            // When it is done, if it is not at the X/Y home, then steps were probably lost!
            strGCode += GotoPositionXY(gdblXMin, gdblYMin, "move X/Y to min endstops");
            
            // Write out the g-code file!
            File.WriteAllText(strOutputFile, strGCode);

            // debug
            //MessageBox.Show(strGCode);
            MessageBox.Show("Generated gcode successfully sent to file:" + crlf + strOutputFile, "Done!");
        }

        // Generate the G-Code!
        string GenerateGCode()
        {
            string strOutputText = "";

            //MessageBox.Show(GenerateCircle(200,100,100,30));

            if (chkBigSquare.Checked == true) strOutputText += GenerateLargeSquare();
            if (chkSmallSquare.Checked == true) strOutputText += GenerateSmallSquare();
            if (chkDiagonals.Checked == true) strOutputText += GenerateDiagonals();
            if (chkLargeCircle.Checked == true) strOutputText += GenerateLargeCircle();
            //if (chkSmallCircle.Checked == true) strOutputText += GenerateSmallCircle();

            return strOutputText;
        }

        // ********************* Large and Small Squares *********************
        /// <summary>
        /// Generate a square path
        /// </summary>
        /// <param name="travelSpeedmms">Travel speed in millimeters per second</param>
        /// <param name="xMin"></param>
        /// <param name="xMax"></param>
        /// <param name="yMin"></param>
        /// <param name="yMax"></param>
        /// <param name="xOffset"></param>
        /// <param name="yOffset"></param>
        /// <param name="comment"></param>
        /// <returns>The g-code for the square</returns>
        string GenerateSquare(int travelSpeedmms, double xMin, double xMax, double yMin, double yMax, double xOffset, double yOffset, string comment)
        {
            double dblXMinSq = xMin + xOffset;
            double dblXMaxSq = xMax - xOffset;
            double dblYMinSq = yMin + yOffset;
            double dblYMaxSq = yMax - yOffset;
            string strOutputText = "";
            strOutputText += AddComment(comment);
            strOutputText += "G1 F" + (travelSpeedmms*60).ToString() + "\t; set XY travel speed to " + travelSpeedmms.ToString() + "mm/s" + crlf;
            strOutputText += GotoPositionXY(dblXMinSq, dblYMinSq, "go to the origin of the square");
            strOutputText += GotoPositionX(dblXMaxSq);
            strOutputText += GotoPositionY(dblYMaxSq);
            strOutputText += GotoPositionX(dblXMinSq);
            strOutputText += GotoPositionY(dblYMinSq);
            strOutputText += AddComment("******* End Box ******");

            return strOutputText + crlf;
        }

        string GenerateLargeSquare()
        {
            // Define the size of square using offsets from min/max values.
            double dblXOffset = 0; // Convert.ToInt16(gintXMax / 10);
            double dblYOffset = 0; // Convert.ToInt16(gintYMax / 10);
            double dblXMinSq = gdblXMin;
            double dblXMaxSq = gdblXMax;
            double dblYMinSq = gdblYMin;
            double dblYMaxSq = gdblYMax;
            string strComment = "******* Begin Large Box at " + gintTravelSpeedmms.ToString() + "mm/s ******";

            // Get the g-code
            string strOutputText = GenerateSquare(gintTravelSpeedmms, dblXMinSq, dblXMaxSq, dblYMinSq, dblYMaxSq, dblXOffset, dblYOffset, strComment);

            // return it
            return strOutputText;
        }

        string GenerateSmallSquare()
        {
            // Define the size of square as 1/4 full build plate size using offsets from min/max values.
            double dblXOffset = Convert.ToInt16(gdblXMax / 4);
            double dblYOffset = Convert.ToInt16(gdblYMax / 4);
            double dblXMinSq = gdblXMin;
            double dblXMaxSq = gdblXMax;
            double dblYMinSq = gdblYMin;
            double dblYMaxSq = gdblYMax;

            string strComment = "******* Begin Small Box at " + gintTravelSpeedmms.ToString() + "mm/s ******";

            // Get the g-code
            string strOutputText = GenerateSquare(gintTravelSpeedmms, dblXMinSq, dblXMaxSq, dblYMinSq, dblYMaxSq, dblXOffset, dblYOffset, strComment);

            // return it
            return strOutputText;
        }
        // ********************************************************************

        // similar to a square...
        string GenerateDiagonals()
        {
            string strComment = "******* Begin diagonal lines at " + gintTravelSpeedmms.ToString() + "mm/s ******";
            //string strOutputText = GenerateDiagonalLines(gintTravelSpeedmms, gintXMin, gintXMax, gintYMin, gintYMax, gintXMax / 10, gintYMax / 10, strComment);
            string strOutputText = GenerateDiagonalLines(gintTravelSpeedmms, gdblXMin, gdblXMax, gdblYMin, gdblYMax, 0, 0, strComment);
            return strOutputText + crlf;
        }

        /// <summary>
        /// Generate g-code for diagonal lines, and travel in both directions.
        /// </summary>
        /// <param name="travelSpeedmms"></param>
        /// <param name="xMin"></param>
        /// <param name="xMax"></param>
        /// <param name="yMin"></param>
        /// <param name="yMax"></param>
        /// <param name="xOffset"></param>
        /// <param name="yOffset"></param>
        /// <param name="comment"></param>
        /// <returns>The g-code</returns>
        string GenerateDiagonalLines(int travelSpeedmms, double xMin, double xMax, double yMin, double yMax, double xOffset, double yOffset, string comment)
        {
            double dblXMinSq = xMin + xOffset;
            double dblXMaxSq = xMax - xOffset;
            double dblYMinSq = yMin + yOffset;
            double dblYMaxSq = yMax - yOffset;
            string strOutputText = "";
            strOutputText += AddComment(comment);
            strOutputText += "G1 F" + (travelSpeedmms * 60).ToString() + "\t; set XY travel speed to " + travelSpeedmms.ToString() + "mm/s" + crlf;

            // 0. Start at origin (plus any offset)
            strOutputText += GotoPositionXY(dblXMinSq, dblYMinSq, "go to the origin of the square");

            // 1. upper right: Origin to max x & y
            strOutputText += GotoPositionXY(dblXMaxSq, dblYMaxSq);

            // 2. lower right: max x, min y
            strOutputText += GotoPositionXY(dblXMaxSq, dblYMinSq);

            // 3. upper left: min x, max y
            strOutputText += GotoPositionXY(dblXMinSq, dblYMaxSq);

            // 4. upper right: go to max x & y
            strOutputText += GotoPositionXY(dblXMaxSq, dblYMaxSq);

            // 5. lower left: go to min x & y
            strOutputText += GotoPositionXY(dblXMinSq, dblYMinSq);

            // 6. upper left: go to max x & y
            strOutputText += GotoPositionXY(dblXMaxSq, dblYMaxSq);

            // 7. lower right: max x, min y
            strOutputText += GotoPositionXY(dblXMaxSq, dblYMinSq);

            strOutputText += AddComment("******* End Diagonal Lines ******");

            return strOutputText + crlf;
        }


        // *********************** Circles and Ellipses ***********************
        //string GenerateEllipse(int travelSpeedmms, int xCenter, int yCenter, int xRadius, int yRadius, int xOffset=0, int yOffset=0, string comment="")
        // start simpler (get it done)
        string GenerateCircle(int travelSpeedmms, double xCenter, double yCenter, double radius, double granularity = 10, double xOffset = 0, double yOffset = 0, string comment = "")
        {
            double xOrigin = xCenter + xOffset;
            double yOrigin = yCenter + yOffset;

            double xMin = xOrigin - radius;
            double xMax = xOrigin + radius;
            double yMin = yOrigin - radius;
            double yMax = yOrigin + radius;

            if (xMin < 0 || yMin < 0 || xMax > gdblXMax || yMax > gdblYMax)
            {
                throw new System.Exception("Circle cannot be outside of the bed max limits!");
            }

            string strOutputText = "";
            strOutputText += AddComment(comment);
            strOutputText += "G1 F" + (travelSpeedmms * 60).ToString() + "\t; set XY travel speed to " + travelSpeedmms.ToString() + "mm/s" + crlf;

            // Get the points on the circle. 
            double curX = xOrigin;
            double curY = yOrigin;
            for (double curAngle = 0; curAngle < 360; curAngle += granularity)
            {
                GetPointsOnCircle(radius, xCenter, yCenter, curAngle, out curX, out curY);
                strOutputText += GotoPositionXY(curX, curY);
            }

            // return it
            return strOutputText + crlf;
        }

        void GetPointsOnCircle(double radius, double xOrigin, double yOrigin, double AngleInDegrees, out double xPoint, out double yPoint)
        {
            double curRadians = Math.PI * AngleInDegrees / 180;
            xPoint = (radius * Math.Cos(curRadians) + xOrigin);
            yPoint = (radius * Math.Sin(curRadians) + yOrigin);
            // TODO: Truncate the number of significant digits; these numbers are much longer than necessary and are bloating the file.
        }

        string GenerateLargeCircle()
        {
            // Define the size of square using offsets from min/max values.
            string strComment = "******* Begin Large Circle at " + gintTravelSpeedmms.ToString() + "mm/s ******";
            double granularity = 360/gdblCircleSegmentCount;
            string strOutputText = GenerateCircle(gintTravelSpeedmms, gdblXMax / 2, gdblYMax / 2, gdblXMax / 4, granularity, 0, 0, strComment);
            strComment = "******* End Large Circle ******";
            strOutputText += AddComment(strComment);
            return strOutputText + crlf;
        }
        // ********************************************************************

        // ********************* G-code Creation Methods **********************
        // Create the g-code to move to a position, with an optional comment at the end of the line.
        string GotoPositionXY(double x, double y = 0, string strComment = "")
        {
            string strOutput = "G1 X" + x.ToString() + " Y" + y.ToString() + (strComment == "" ? "" : "\t; " + strComment);
            return strOutput + crlf;
        }
        string GotoPositionX(double x, string strComment = "")
        {
            string strOutput = "G1 X" + x.ToString() + (strComment=="" ? "" : "\t; " + strComment);
            return strOutput + crlf;
        }

        string GotoPositionY(double y = 0, string strComment = "")
        {
            string strOutput = "G1 Y" + y.ToString() + (strComment == "" ? "" : "\t; " + strComment);
            return strOutput + crlf;
        }
        string AddComment(string strComment = "")
        {
            string strOutput = "";
            strOutput += "; " + strComment;
            return strOutput + crlf;
        }

        private void btnOpenInNotepad_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(txtFileName.Text, "notepad.exe");
        }
        // ********************************************************************
    }
}
