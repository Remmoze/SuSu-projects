#include <iostream>
#define growthFactor 1.75
#define initialSize 5

struct Queue {
	int* p;
	int cur = 0;
	int max = initialSize;
};

void init(struct Queue* qunue) {
	qunue->p = (int*)malloc(qunue->max * sizeof(int));
	if(qunue->p == nullptr) exit(-1);
}

void resize(struct Queue* qunue) {
	if(qunue->cur < qunue->max) return;
	qunue->p = (int*)realloc(qunue->p, qunue->max * growthFactor * sizeof(int));
	qunue->max *= growthFactor;
	if(qunue->p == nullptr) exit(-1);
}

void push(struct Queue* qunue, int value) {
	resize(qunue);
	qunue->p[qunue->cur++] = value;
}

bool isEmpty(struct Queue* qunue) {
	return qunue->cur <= 0;
}

void pop(struct Queue* qunue) {
	for(int i = 1; i < qunue->cur; i++)
		qunue->p[i - 1] = qunue->p[i];
	--qunue->cur;
};
int front(struct Queue* qunue) {
	return qunue->p[0];
};
int size(struct Queue* qunue) {
	return qunue->cur;
}
void clear(struct Queue* qunue) {
	qunue->cur = 0;
}
void print(struct Queue* qunue) {
	for(int i = 0; i < qunue->cur; i++) {
		std::cout << qunue->p[i];
	}
	std::cout << std::endl;
}

int main() {
	Queue qunue;
	init(&qunue);
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