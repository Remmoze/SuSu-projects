#include <iostream>
#define growthFactor 2
#define initialSize 10

struct Deque {
	int* p;
	int start = initialSize / 2;
	int end = initialSize / 2;
	int max = initialSize;
};

void init(struct Deque* deque) {
	deque->p = (int*)malloc(deque->max * sizeof(int));
	if(deque->p == nullptr) exit(-1);
}

void resize(struct Deque* deque) {
	if(deque->end < deque->max) return;
	deque->p = (int*)realloc(deque->p, deque->max * growthFactor * sizeof(int));
	deque->max *= growthFactor;
	if(deque->p == nullptr) exit(-1);
}

void push_front(struct Deque* deque, int value) {
	resize(deque);
	if(deque->start == 0) {
		for(int i = deque->end; i > 0; i--) //move everything to the right
			deque->p[i] = deque->p[i - 1];
		deque->p[0] = value;
		deque->end++;
	} else deque->p[--deque->start] = value;
}

void push_back(struct Deque* deque, int value) {
	resize(deque);
	deque->p[deque->end++] = value;
}

int pop_front(struct Deque* deque) {
	return deque->p[deque->start++];
};

int pop_back(struct Deque* deque) {
	return deque->p[--deque->end];
};

int front(struct Deque* deque) {
	return deque->p[0];
};

int back(struct Deque* deque) {
	return deque->p[deque->end - 1];
};
int size(struct Deque* deque) {
	return deque->end - deque->start;
}
void clear(struct Deque* deque) {
	deque->end = deque->start = initialSize / 2;
}

bool isEmpty(struct Deque* deque) {
	return deque->end == deque->start;
}

void print(struct Deque* deque) {
	for(int i = deque->start; i < deque->end; i++) {
		std::cout << deque->p[i];
	}
	std::cout << std::endl;
}

int main() {
	Deque deque;
	init(&deque);
	std::string input;
	int inp;
	do {
		std::cin >> input;
		if(input == "push_front") {
			std::cin >> inp;
			push_front(&deque, inp);
			std::cout << "ok" << std::endl;
		} else if(input == "push_back") {
			std::cin >> inp;
			push_back(&deque, inp);
			std::cout << "ok" << std::endl;
		} else if(input == "pop_front") {
			if(isEmpty(&deque)) {
				std::cout << "error" << std::endl;
				continue;
			}
			std::cout << pop_front(&deque) << std::endl;
		} else if(input == "pop_back") {
			if(isEmpty(&deque)) {
				std::cout << "error" << std::endl;
				continue;
			}
			std::cout << pop_back(&deque) << std::endl;
		} else if(input == "front") {
			if(isEmpty(&deque)) {
				std::cout << "error" << std::endl;
				continue;
			}
			std::cout << front(&deque) << std::endl;
		} else if(input == "back") {
			if(isEmpty(&deque)) {
				std::cout << "error" << std::endl;
				continue;
			}
			std::cout << back(&deque) << std::endl;
		} else if(input == "size") {
			std::cout << size(&deque) << std::endl;
		} else if(input == "clear") {
			clear(&deque);
			std::cout << "ok" << std::endl;
		} else if(input == "print") {
			print(&deque);
		}
	} while(input != "exit");
	std::cout << "bye" << std::endl;
	return 0;
}