#include <stdio.h>
#define _USE_MATH_DEFINES
#include <math.h>

double funcA(float a) {
	if (a <= 0)
		return 0;
	if (a < 1)
		return pow(a, 2) - a;
	return pow(a, 2) - sin(M_PI * pow(a, 2));
};

int main()
{
	float a;
	printf("a: ");
	scanf_s("%f", &a);

	printf("\nf(a) = %f", (float)funcA(a));

	printf("\n\nPress any key to continue..");
	_getch();
	return 0;
}