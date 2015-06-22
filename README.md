# PID_Tunning_Tool

/*Ziegler–Nichols_method*/ <br>
    kp=((kp*3.3)/(4.5));<br>
    ki=2*kp; <br>
    kd=kp/8; <br>

<font size =10>
<i><b>Ziegler–Nichols method</i></b><br><br>
<b>Control Type K_p, 	K_i, K_d:</b><br>
</font>

<font size = 5>
<b>P:</b>	0.5 * K_u	        -	        -

<b>PI:</b>	0.45 * K_u	1.2 * K_p/T_u	-

<b>PD:</b>	0.8 * K_u,	- ,	K_p * T_u/8

<b>classic PID:</b>	0.60 * K_u,	2 * K_p/T_u,	K_p * T_u/8,

<b>Pessen Integral Rule:</b>	0.7 * K_u,	2.5 * K_p/T_u,	3 * K_p * T_u/20,

<b>some overshoot:</b> 	0.33 * K_u,	2 * K_p/T_u,	K_p * T_u/3,

<b>no overshoot:</b>	0.2 * K_u,	2 * K_p/T_u,	K_p * T_u/3,
</font>
