#include <iostream>

#define MAX_SIZE 100
class Stack {
public:
	void push(int value) {
		elements[cur++] = value;
	};
	void pop() {
		--cur;
	};
	int back() {
		return elements[cur-1];
	};
	int size() {
		return cur;
	}
	void clear() {
		cur = 0;
	}
	void print() {
		for(int i = 0; i < cur; i++) {
			std::cout << elements[i];
		}
		std::cout << std::endl;
	}
private:
	int cur = 0;
	int elements[MAX_SIZE];
};

int main() {
	Stack stack;
}