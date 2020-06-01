#include <iostream>
#define MAX_SIZE 100

struct Stack {
	int cur = 0;
	int elements[MAX_SIZE];
};

void push(struct Stack* stack, int value) {
	stack->elements[stack->cur++] = value;
}

void pop(struct Stack* stack) {
	--stack->cur;
};
int back(struct Stack* stack) {
	return stack->elements[stack->cur - 1];
};
int size(struct Stack* stack) {
	return stack->cur;
}
void clear(struct Stack* stack) {
	stack->cur = 0;
}
void print(struct Stack* stack) {
	for(int i = 0; i < stack->cur; i++) {
		std::cout << stack->elements[i];
	}
	std::cout << std::endl;
}

int main() {
	Stack stack;
	std::string input;
	int inp;
	do {
		std::cin >> input;
		if(input == "push") {
			std::cin >> inp;
			push(&stack, inp);
			std::cout << "ok" << std::endl;
		} else if(input == "pop") {
			std::cout << back(&stack) << std::endl;
			pop(&stack);
		} else if(input == "back") {
			std::cout << back(&stack) << std::endl;
		} else if(input == "size") {
			std::cout << size(&stack) << std::endl;
		} else if(input == "clear") {
			clear(&stack);
			std::cout << "ok" << std::endl;
		}
	} while(input != "exit");
	std::cout << "bye" << std::endl;
	return 0;
}