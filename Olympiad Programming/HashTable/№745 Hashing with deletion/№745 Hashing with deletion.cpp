#include <iostream>
#include <string.h>
#define size 32768

struct Node {
	char* value;
	Node* next = nullptr;
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

Node* hashtable[size];
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

void insert(Node* node) {
	auto p = hashtable[hash(node->value)];
	while(p && p->next) {
		if(strcmp(node->value, p->value) == 0)
			return;
		p = p->next;
	}
	if(!p) hashtable[hash(node->value)] = node;
	else if(!p->next) {
		if(strcmp(node->value, p->value) == 0)
			return;
		p->next = node;
	}
}

void remove(char* str) {
	auto hashed = hash(str);
	auto p = hashtable[hash(str)];
	auto prev = p;
	bool stepped = 0;
	while(p && p->next) {
		if(strcmp(str, p->value) == 0) {
			if(stepped) prev->next = p->next;
			else hashtable[hashed] = p->next;
			return;
		}
		prev = p;
		p = p->next;
		stepped = 1;
	}
	if(!p) return; // no values were found, nothing to delete
	else if(!p->next) {
		if(strcmp(str, p->value) == 0) {
			hashtable[hashed] = nullptr;
			return;
		}
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
			Node* node = new Node;
			node->value = str;
			insert(node);
		} else if(strcmp(input, "-") == 0) {
			char* str = (char*)calloc(10, sizeof(char));
			std::cin >> str;
			remove(str);
		}
	}
}