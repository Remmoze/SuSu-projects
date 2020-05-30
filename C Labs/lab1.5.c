#include <stdio.h>

int main()
{
	int n = 0;
	printf("n: ");
	scanf_s("%i", &n);

	float product = 1.;

	for (float i = 1; i <= n; i++) {
		product *= 1 + 1 / (i * i);
	}

	printf("\nThe product is: %f", product);


	printf("\n\nPress any key to continue..\n");
	_getch();
	return 0;
}