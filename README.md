# PID_Tunning_Tool

/*Ziegler–Nichols_method*/
    kp=((kp*3.3)/(4.5));
    ki=2*kp;
    kd=kp/8;

Ziegler–Nichols method
Control Type	K_p		K_i		K_d
	P	0.5 K_u		-		-
	PI	0.45 K_u	1.2 K_p/T_u	-
	PD	0.8 K_u		-		K_p T_u/8
classic PID	0.60 K_u	2 K_p/T_u	K_p T_u/8
PessenIntegral  0.7 K_u		2.5 K_p/T_u	3 K_p T_u/20
some overshoot	0.33 K_u	2 K_p/T_u	K_pT_u/3
no overshoot	0.2 K_u		2 K_p/T_u	K_pT_u/3
