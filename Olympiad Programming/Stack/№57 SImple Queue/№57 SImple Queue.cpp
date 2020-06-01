#include <iostream>
#define MAX_SIZE 100

struct Queue {
	int cur = 0;
	int elements[MAX_SIZE];
};

void push(struct Queue* stack, int value) {
	stack->elements[stack->cur++] = value;
}

void pop(struct Queue* stack) {
	for(int i = 1; i < stack->cur; i++)
		stack->elements[i - 1] = stack->elements[i];
	--stack->cur;
};
int front(struct Queue* stack) {
	return stack->elements[0];
};
int size(struct Queue* stack) {
	return stack->cur;
}
void clear(struct Queue* stack) {
	stack->cur = 0;
}
void print(struct Queue* stack) {
	for(int i = 0; i < stack->cur; i++) {
		std::cout << stack->elements[i];
	}
	std::cout << std::endl;
}

int main() {
	Queue stack;
	std::string input;
	int inp;
	do {
		std::cin >> input;
		if(input == "push") {
			std::cin >> inp;
			push(&stack, inp);
			std::cout << "ok" << std::endl;
		} else if(input == "pop") {
			std::cout << front(&stack) << std::endl;
			pop(&stack);
		} else if(input == "front") {
			std::cout << front(&stack) << std::endl;
		} else if(input == "size") {
			std::cout << size(&stack) << std::endl;
		} else if(input == "clear") {
			clear(&stack);
			std::cout << "ok" << std::endl;
		} else if(input == "print") {
			print(&stack);
		}
	} while(input != "exit");
	std::cout << "bye" << std::endl;
	return 0;
}