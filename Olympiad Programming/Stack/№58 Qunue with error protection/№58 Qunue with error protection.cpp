#include <iostream>
#define MAX_SIZE 100

struct Queue {
	int cur = 0;
	int elements[MAX_SIZE];
};

void push(struct Queue* qunue, int value) {
	qunue->elements[qunue->cur++] = value;
}

bool isEmpty(struct Queue* qunue) {
	return qunue->cur <= 0;
}

void pop(struct Queue* qunue) {
	for(int i = 1; i < qunue->cur; i++)
		qunue->elements[i - 1] = qunue->elements[i];
	--qunue->cur;
};
int front(struct Queue* qunue) {
	return qunue->elements[0];
};
int size(struct Queue* qunue) {
	return qunue->cur;
}
void clear(struct Queue* qunue) {
	qunue->cur = 0;
}
void print(struct Queue* qunue) {
	for(int i = 0; i < qunue->cur; i++) {
		std::cout << qunue->elements[i];
	}
	std::cout << std::endl;
}

int main() {
	Queue qunue;
	std::string input;
	int inp;
	do {
		std::cin >> input;
		if(input == "push") {
			std::cin >> inp;
			push(&qunue, inp);
			std::cout << "ok" << std::endl;
		} else if(input == "pop") {
			if(isEmpty(&qunue)) {
				std::cout << "error" << std::endl;
				continue;
			}
			std::cout << front(&qunue) << std::endl;
			pop(&qunue);
		} else if(input == "front") {
			if(isEmpty(&qunue)) {
				std::cout << "error" << std::endl;
				continue;
			}
			std::cout << front(&qunue) << std::endl;
		} else if(input == "size") {
			std::cout << size(&qunue) << std::endl;
		} else if(input == "clear") {
			clear(&qunue);
			std::cout << "ok" << std::endl;
		} else if(input == "print") {
			print(&qunue);
		}
	} while(input != "exit");
	std::cout << "bye" << std::endl;
	return 0;
}