#include <iostream>
#define size 32767

struct node {
	char* value;
	int hashed;
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