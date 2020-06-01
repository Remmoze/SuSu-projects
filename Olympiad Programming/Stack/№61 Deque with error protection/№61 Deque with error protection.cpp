#include <iostream>
#define MAX_SIZE 100

struct Deque {
	int cur = 0;
	int end = MAX_SIZE;
	int elements[MAX_SIZE];
};

void push_front(struct Deque* deque, int value) {
	for(int i = deque->cur; i > 0; i--) //move everything to the right
		deque->elements[i] = deque->elements[i - 1];
	deque->elements[0] = value;
	deque->cur++;
}

void push_back(struct Deque* deque, int value) {
	deque->elements[deque->cur++] = value;
}

int pop_front(struct Deque* deque) {
	int value = deque->elements[0];
	for(int i = 0; i < deque->cur; i++)
		deque->elements[i] = deque->elements[i + 1];
	--deque->cur;
	return value;
};

int pop_back(struct Deque* deque) {
	return deque->elements[--deque->cur];
};

int front(struct Deque* deque) {
	return deque->elements[0];
};

int back(struct Deque* deque) {
	return deque->elements[deque->cur - 1];
};
int size(struct Deque* deque) {
	return deque->cur;
}
void clear(struct Deque* deque) {
	deque->cur = 0;
}

bool isEmpty(struct Deque* deque) {
	return deque->cur <= 0;
}

void print(struct Deque* deque) {
	for(int i = 0; i < deque->cur; i++) {
		std::cout << deque->elements[i];
	}
	std::cout << std::endl;
}

int main() {
	Deque deque;
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