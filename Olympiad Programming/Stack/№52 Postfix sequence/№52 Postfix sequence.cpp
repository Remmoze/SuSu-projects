#include <iostream>
#include <fstream>
#include "ctype.h"

#define growthFactor 1.75
#define initialSize 5

struct Stack {
	int* p;
	int cur = 0;
	int max = initialSize;
};

void init(struct Stack* stack) {
	stack->p = (int*)malloc(stack->max * sizeof(int));
	if(stack->p == nullptr) exit(-1);
}

void resize(struct Stack* stack) {
	if(stack->cur < stack->max) return;
	stack->p = (int*)realloc(stack->p, stack->max * growthFactor * sizeof(int));
	stack->max *= growthFactor;
	if(stack->p == nullptr) exit(-1);
}

void push(struct Stack* stack, int value) {
	resize(stack);
	stack->p[stack->cur++] = value;
}

int pop(struct Stack* stack) {
	return stack->p[--stack->cur];
};

void print(struct Stack* stack) {
	for(int i = 0; i < stack->cur; i++) {
		std::cout << stack->p[i];
	}
	std::cout << std::endl;
}

int main() {
	Stack stack;
	init(&stack);
	std::ifstream inp("./input.txt");
	if(!inp.is_open()) {
		std::cout << "ALARM!";
		return 0;
	}
	char val;
	while(inp >> val) {
		if(isdigit(val)) {
			push(&stack, (int)(val - '0'));
		} else {
			int v2 = pop(&stack);
			int v1 = pop(&stack);
			switch(val) {
				case '+': push(&stack, v1 + v2); break;
				case '-': push(&stack, v1 - v2); break;
				case '*': push(&stack, v1 * v2); break;
			}
			//printf("%i %c %i = %i\n", v1, val, v2, stack.p[stack.cur - 1]);
		}
		//printf("%c ", val);
	}
	inp.close();
	printf("%i", pop(&stack));
	return 0;
}