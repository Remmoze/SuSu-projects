#include <stdio.h>
#include <math.h>

#define limit 15
char is_prime(int num) {
	if(num % 2 == 0) return 0;
	for(int i = 3; i < sqrt(num); i+=2) {
		if(num % i == 0) return 0;
	}
	return 1;
}


int main() {
	int n = 6;
	int m = 6;
	int mat[limit][limit] = {
		{1,		2,		3,		4,		5,		7},
		{12,	72,		87,		83,		42,		149},
		{95,	35,		277,	193,	18,		29},
		{1531,	84,		95,		3,		83,		63},
		{11,	22,		1151,	44,		55,		66},
		{64,	2389,	61,		85,		7,		11},
	};
	int a[limit];

	int sum = 0;
	for(int i = 0; i < m; i++) {
		for(int j = 0; j < n; j++) {
			if(is_prime(mat[j][i]))
				sum += mat[j][i];
		}
		a[i] = sum;
		sum = 0;
	}

	printf("\na = {");
	for(int i = 0; i < n - 1; i++)
		printf("%d, ", a[i]);
	printf("%d}\n", a[n - 1]);

}