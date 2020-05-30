#include <stdio.h>
#include <stdlib.h>

#define SIZE 100

int main() {
    int n;
    int a[SIZE];
    int b[SIZE];

    printf("size: ");  scanf_s("%i", &n);

    if (n <= 0) return 0;
    if (n > SIZE) n = SIZE;

    printf("\nWrite numbers by hand? Y/N\n");
    char answer = 'N';
    scanf_s(" %c", &answer);

    //set up a
    int temp = 0;
    srand(n);
    for (int i = 0; i < n; i++) {
        if (answer == 'N')
            a[i] = rand() % 100;
        else {
            printf(" >");
            scanf_s(" %i", &temp);
            a[i] = temp;
        }
    }

    //visualize a
    printf("\na = {");
    for (int i = 0; i < n-1; i++) {
        printf("%d, ", a[i]);
    }
    printf("%d}\n", a[n - 1]);
    
    //calculate
    int sum = 0;
    for (int i = 0; i < n; i++) sum += a[i];
    for (int i = 0; i < n; i++) b[i] = (sum - a[i]) / (n - 1);

    //visualize b
    printf("\nb = {");
    for (int i = 0; i < n - 1; i++) {
        printf("%d, ", b[i]);
    }
    printf("%d}\n", b[n - 1]);

}