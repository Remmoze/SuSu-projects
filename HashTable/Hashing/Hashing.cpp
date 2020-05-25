#include <iostream>
#include <string.h>
#define size 32768

struct node {
	char* value;
	node* next = nullptr;
};

static const unsigned int FNV_PRIME = 16777619u;
static const unsigned int OFFSET_BASIS = 2166136261u;

int hash(char* data) {
	const size_t length = 11;
	unsigned int hash = OFFSET_BASIS;
	for(size_t i = 0; i < length; ++i) {
		if(data[0] == '\0')
			break;
		hash ^= *data++;
		hash *= FNV_PRIME;
	}
	return hash % size;
}

node* hashtable[size];
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
			node* Node = new node;
			Node->value = str;
			insert(Node);
		}
	}
}