#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int main()
{

    unsigned char * data1 = "ion n-are pere";
    unsigned char * data2 = "ana are mere";
    //read data from UART

    // if first char from message is 'S' then set desired speed with value from PC

    // else if first char from message is 'C' then set Kp, Ki, Kd, for PID regulator


    //Desired Speed must be declared Volatile!!!!
    //char mes1[] = "S,1000";
    char mes1[] = "C,4.00056,2.3,0.02";
    char * buf1;
    printf("first element: %c \n\n", mes1[0]);
    printf("this is the whole message:\r\n%s",mes1);
    buf1 = strtok(mes1,",");
    printf("\n\nPrimul: %s\n\n",buf1);
    //printf("\r\n%c\n%c\n%c\n%c\n%c\n",buf1[0],buf1[1],buf1[2],buf1[3],buf1[4]);
    buf1 = strtok(NULL,",");
    printf("\nsecond: %s",buf1);
    float desiredFloat =atof(buf1);
    printf("\n\nMy float is: %.5f",desiredFloat);
    printf("\n\nData1 :%s si data2: %s inainte de orice modificare\n",data1,data2);
    data1 = data2;
    printf("\n\nData1 :%s si data2: %s after equalite\n",data1,data2);

    //printf("Hello world!\n");
    return 0;
}
