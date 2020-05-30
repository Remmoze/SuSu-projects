#include <stdio.h>
#include <math.h>
int main() {
	int x, y, z;
	printf("x, y, z:");
	scanf_s("%d %d %d", &x, &y, &z);

	double a, b;
	a = (3 + exp(y - 1)) / (1 + pow(x, 2) * fabs(y - tan(x)));
	b = 1 + fabs(y - x) + pow(y - x, 2) / 2 + pow(fabs(y - x), 3) / 3;

	printf("\na = %f", a);
	printf("\nb = %f", b);

	printf("\n\nPress any key to continue..");
	_getch();
	return 0;
}