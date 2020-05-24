#include <iostream>
#include <string.h>
#define size 1024

struct node {
	char* value;
	node* next = nullptr;
};

int hash(char* data) {
	int sum = 0;
	for(int i = 0; i < 10; i++) {
		if(data[i] == '\0')
			break;

		sum += (char)data[i] * (i + 1) * 1103515245 + 12345;
	}
	return abs(sum) % size;
}

node* hashtable[size];
node* getNew(char* data) {
	return elem;
}

bool lookup(char* data) {
	auto p = hashtable[hash(data)];
	while(p) {
		if(strcmp(data, p->value) == 0)
			return true;
		if(!p->next) return false;
		p = p->next;
	}
	return false;
}

void insert(node* Node) {
	auto p = hashtable[hash(Node->value)];
	while(p && p->next) {
		if(strcmp(Node->value, p->value) == 0)
			return;
		p = p->next;
	}
	if(!p) hashtable[hash(Node->value)] = Node;
	else if(!p->next) {
		if(strcmp(Node->value, p->value) == 0)
			return;
		p->next = Node;
	}
}

int main() {
	char* input = (char*)calloc(10, sizeof(char));
	while(true) {
		std::cin >> input;
		if(strcmp(input, "#") == 0)
			break;
		if(strcmp(input, "?") == 0) {
			std::cin >> input;
			printf(lookup(input) ? "YES\n" : "NO\n");
		} else if(strcmp(input, "+") == 0) {
			char* str = (char*)calloc(10, sizeof(char));
			std::cin >> str;
			node * Node = new node;
			Node->value = str;
			insert(Node);
		}
	}
}