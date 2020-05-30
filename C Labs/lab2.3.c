#include <stdio.h>

#define limit 15

int main() {
	int a[limit] = {1, 2, 3, 6, 7, 8, 10, 56, 58, 59};
	int n = 10;

	printf("\na = {");
	for(int i = 0; i < n - 1; i++)
		printf("%d, ", a[i]);
	printf("%d}\n", a[n - 1]);

	int bad = -1;
	for(int i = 0; i < n - 1; i++) {
		if(a[i] < a[i + 1]) continue;
		bad = a[i + 1];
		break;
	}

	if(bad == -1) {
		for(int i = 1; i < n; i += 2) {
			int BBB = i / 2;
			int AAA = i / 2;
			a[i / 2] = a[i];
		}
		for(int i = n / 2; i < n; i++) a[i] = 0;
		n = n/2;
	} else {
		n++;
		for(int i = n-2; i >= (n-1)/2; i--) {
			a[i + 1] = a[i];
		}
		a[(n - 1) / 2] = bad;
	}

	printf("\na = {");
	for(int i = 0; i < n - 1; i++)
		printf("%d, ", a[i]);
	printf("%d}\n", a[n - 1]);

}

/*

	//visualize b
	printf("\na = {");
	for (int i = 0; i < 20 - 1; i++)
		printf("%d, ", a[i]);
	printf("%d}\n", a[20 - 1]);
*/