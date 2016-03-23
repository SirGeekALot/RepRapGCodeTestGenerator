G28		; home all axes
G90		; use absolute positioning
G21		; use metric values
G1 X0 Y0	; move X/Y to min endstops
G1 Z8.0 F600	; move the platform down 8mm at 10mm/s

;========== Begin Loop # 1 ==========
; ******* Begin Large Box at 350mm/s ******
G1 F21000	; set XY travel speed to 350mm/s
G1 X0 Y0	; go to the origin of the square
G1 X200
G1 Y200
G1 X0
G1 Y0
; ******* End Box ******

; ******* Begin Small Box at 350mm/s ******
G1 F21000	; set XY travel speed to 350mm/s
G1 X50 Y50	; go to the origin of the square
G1 X150
G1 Y150
G1 X50
G1 Y50
; ******* End Box ******

; ******* Begin diagonal lines at 350mm/s ******
G1 F21000	; set XY travel speed to 350mm/s
G1 X0 Y0	; go to the origin of the square
G1 X200 Y200
G1 X200 Y0
G1 X0 Y200
G1 X200 Y200
G1 X0 Y0
G1 X200 Y200
G1 X200 Y0
; ******* End Diagonal Lines ******


;========== End Loop # 1 ==========
G1 X0 Y0	; move X/Y to min endstops
