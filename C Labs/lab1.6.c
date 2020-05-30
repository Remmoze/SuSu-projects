#include <stdio.h>


int main()
{
	float E;
	printf("Precision: ");
	scanf_s("%f", &E);

	float sum = 0;
	for (float i = 1;; i++) {
		float val = 1 / (i * i);
		if (val < E)
			break;
		sum += val;
	}

	printf("\nTotal sum: %f", sum);

	printf("\n\nPress any key to continue..\n");
	_getch();
	return 0;
}

