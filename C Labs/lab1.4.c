#include <stdio.h>

int main()
{
	int input;
	int count = 0;
	unsigned long long int mult = 1;

	do {
		printf("\nNumber > ");
		if (scanf_s("%i", &input) != 1) {
			printf("\nNot a valid number.");
			return 0;
		}

		if (input == 0) {
			break;
		}

		if (input % 2 == 0) {
			count++;
			mult *= input;
		}

	} while (1);

	if (count == 0) {
		printf("\nNo even numbers were given.");
	}
	else {
		printf("\n%i even numbers were given and their product is %i", count, mult);
	}

	printf("\n\nPress any key to continue..\n");
	_getch();
	return 0;
}