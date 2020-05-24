#include <iostream>
#define size 256

struct node {
	char* value;
	int hashed;
	node* next = nullptr;
};

int hash(char* data) {
	int sum = 0;
	for(int i = 0; i < 10; i++) {
		if(data[i] == '\0')
			break;

		//sum += (char)data[i] * (i+1) * 1103515245 + 12345; //just to add some sort of randomness to it
		sum += (char)data[i];
	}
	return abs(sum) % size;
}

node* hashtable[size];
node* getNew(char* data) {
	node* elem = new node;
	elem->value = data;
	elem->hashed = hash(data);
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
	auto p = hashtable[Node->hashed];
	while(p && p->next) p = p->next;
	if(!p) hashtable[Node->hashed] = Node;
	else if(!p->next) p->next = Node;
	printf("%s -> %i\n", Node->value, Node->hashed);
}

void print() {
	for(int i = 0; i < size; i++) {
		if(hashtable[i] == nullptr) continue;
		printf("[%i]: %s", i, hashtable[i]->value);
		auto child = hashtable[i]->next;
		while(child != nullptr) {
			printf(" -> %s", child->value);
			child = child->next;
		}
		printf("\n");
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
			node* Node = getNew(str);
			insert(Node);
		} else if(strcmp(input, "%") == 0) {
			print();
		}
	}
}