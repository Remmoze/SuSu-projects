#include <iostream>
#include <cstring>
#include <tgmath.h>


// I GIVE UP.


int* p;
int end = 0; //end marks the value next to the existing one.

inline void move(int from) {
	memmove(p + from + 1, p+from, (end - from) * sizeof(int));
}

void push(int value, bool middle = false) {
	if(middle) {
		int pos = ceil((end-1) / 2.0f);
		move(pos);
		p[pos] = value;
		end++;
		return;
	}
	p[end++] = value;
}

void pop() {
	memmove(p, p + 1, end-- * sizeof(int));
}

int main()
{
	char symbol;
	int inp;
	std::cin >> inp;
	int size = inp;
	p = new int[100000];
	for(int i = 0; i < size; i++) {
		std::cin >> symbol;
		if(symbol == '-') {
			printf("%i\n", p[0]);
			pop();
			continue;
		}
		std::cin >> inp;
		push(inp, symbol == '*');
	}
	
}