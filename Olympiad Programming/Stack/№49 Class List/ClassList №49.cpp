#include <iostream>
#include <locale.h>
#include <fstream>
#include <string>

struct node {
	std::string value;
	node* next = nullptr;
};
class list {
private:
	node* first = nullptr;
	node* last = nullptr;
	int clas = 0;
public:
	list(int _clas) {
		clas = _clas;
	}
	void push(std::string val) {
		node* element = new node();
		element->value = val;
		if(first == nullptr) 
			first = element; 
		else last->next = element;
		last = element;
		
	}
	void print() {
		if(first == nullptr) return;
		node* cur = first;
		do {
			std::cout << clas << " " << cur->value << std::endl;
			cur = cur->next;
		} while(cur != nullptr);
	}
};

int main() {
	setlocale(LC_ALL, "");
	list c9(9);
	list c10(10);
	list c11(11);
	std::ifstream inp("./input.txt");
	if(!inp.is_open()) {
		std::cout << "ALARM!";
		return 0;
	}
	std::string lastname;
	int clas;
	while(inp >> clas) {
		inp >> lastname;
		if(clas == 9) c9.push(lastname);
		else if(clas == 10) c10.push(lastname);
		else if(clas == 11) c11.push(lastname);
	}
	inp.close();
	c9.print();
	c10.print();
	c11.print();
	return 0;
}