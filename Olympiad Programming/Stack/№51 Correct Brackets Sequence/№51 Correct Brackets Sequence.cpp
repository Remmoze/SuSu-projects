#include <iostream>
#include <fstream>

#define MAX_SIZE 100000

int cur = 0;
char elements[MAX_SIZE];


void push(char value) {
	elements[cur++] = value;
};
void pop() {
	--cur;
}; 

int size() {
	return cur;
}
int back() {
	return elements[cur-1];
}

void smartpush(char value) {
	if(value == ')' && back() == '(')
		pop();
	else if(value == '}' && back() == '{')
		pop();
	else if(value == ']' && back() == '[')
		pop();
	else push(value);
}

void print() {
	for(int i = 0; i < cur; i++) {
		std::cout << elements[i];
	}
	std::cout << std::endl;
}

int main() {
	std::ifstream inp("./input.txt");
	if(!inp.is_open()) {
		std::cout << "ALARM!";
		return 0;
	}
	char val;
	while(inp >> val)
		smartpush(val);
	inp.close();
	
	if(size() == 0) printf("yes");
	else printf("no");
	return 0;
}