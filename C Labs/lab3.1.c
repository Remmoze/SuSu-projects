#include <stdio.h> 
#include <stdlib.h> 

#define growFactor 1.75f
#define	printall(z) PrintDA(z); PrintDAFull(z); printf("\n");

struct DynamicArray {
	int* p;
	int size;
	int capacity;
};

void PrintDA(struct DynamicArray* da) {
	for(int i = 0; i < da->size; i++) {
		printf("[%i], ", (da->p)[i]);
	}
	printf("\n");
}
void PrintDAFull(struct DynamicArray* da) {
	for(int i = 0; i < da->capacity; i++) {
		if(i == da->size)
			printf("\033[1;31m");
		printf("[%i], ", (da->p)[i]);
	}
	printf("\033[0m");
	printf("\n");
}

void AllocMore(struct DynamicArray* da, int newSize) {
	short IsNew = (da->p == NULL);
	if((da->p = realloc(da->p, newSize * sizeof(int))) == NULL) {
		printf("Failed to reallocate memory.");
		exit(-1);
	}
	if(!IsNew) {
		for(int i = da->capacity; i < newSize; i++) {
			(da->p)[i] = 0;
		}
	}
	da->capacity = newSize;
}

void CheckSize(struct DynamicArray* da) {
	if(da->size < da->capacity) return;
	AllocMore(da, da->size * growFactor);
}

int getAt(struct DynamicArray* da, int index) {
	return da->p[index];
}

void setAt(struct DynamicArray* da, int index, int value) {
	da->p[index] = value;
}

void push(struct DynamicArray* da, int value) {
	da->p[da->size] = value;
	da->size++;
	CheckSize(da);
}

void pop(struct DynamicArray* da) {
	da->size--;
}

int main()
{
	struct DynamicArray da = {NULL, 0, 3};
	AllocMore(&da, da.capacity);

	for(int i = 0; i < 4; i++) {
		push(&da, (i + 1) * 10);
	}

	printall(&da);

	push(&da, 50);
	push(&da, 60);
	push(&da, 70);
	printall(&da);

	pop(&da);
	setAt(&da, 1, 100);
	printall(&da);

	printf("value at [%i] is {%i}", 1, getAt(&da, 1));


}