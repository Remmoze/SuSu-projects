#include <stdio.h>

int main()
{
	int a;
	printf("a: ");
	scanf_s("%i", &a);

	if (a < 1000 || a >= 10000) {
		printf("\nValue must contain 4 digits");
		return 0;
	}

	if (a / 1000 == a % 10 && (a / 100) % 10 == (a / 10) % 10)
		printf("\n%i is a palindrome.", a);
	else 
		printf("\n%i is not a palindrome.", a);

	printf("\n\nPress any key to continue..");
	_getch();
	return 0;
}