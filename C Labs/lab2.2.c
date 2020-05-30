#include <stdio.h>

int main() {
	int a[] = {1, 50, 32, 123, 12, 95, 31, 85, 52, 10000};
	int size = sizeof(a) / sizeof(a[0]);

	printf("\na = {");
	for (int i = 0; i < size - 1; i++)
		printf("%d, ", a[i]);
	printf("%d}\n", a[size - 1]);

	int max = 0;
	for (int i = 0; i < size; i++) {
		if (max < a[i])
			max = a[i];
	}
	for (int i = 0; i < size; i++) {
		a[i] = a[i] == max ? 1 : 0;
	}

	printf("\na = {");
	for (int i = 0; i < size - 1; i++) 
		printf("%d, ", a[i]);
	printf("%d}\n", a[size - 1]);

}

/*

	//visualize b
	printf("\nb = {");
	for (int i = 0; i < n - 1; i++) {
		printf("%d, ", b[i]);
	}
	printf("%d}\n", b[n - 1]);
*/