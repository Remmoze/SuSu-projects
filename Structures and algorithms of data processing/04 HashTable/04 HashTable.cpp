#include <iostream>
#define size 16

struct node {
	char value;
	int count;
	node* next = nullptr;
};

// ���-������� "Fowler�Noll�Vo". ������������ ����������� ������������� ������
// � ���-������� � ����������� ����������� ��������.
static const unsigned int FNV_PRIME = 16777619u;
static const unsigned int OFFSET_BASIS = 2166136261u;
int hash(char data) {
	unsigned int hash = OFFSET_BASIS;
	hash ^= data;
	hash *= FNV_PRIME;
	return hash % size;
}

// ����������� ���-�������
node* hashtable[size];
// ������� ��� ����������� ������ �������� � ���-�������
node* getNew(char data) {
	node* elem = new node;
	elem->value = data;
	elem->count = 1;
	return elem;
}

// ����� ����� � ���-�������
int lookup(char data) {
	// ����� ������� �� ���-�������
	auto p = hashtable[hash(data)];
	while(p) {
		// ������� �����, ����������� ����������
		if(data == p->value)
			return p->count;
		//���� ��� ���������� �������� - � ����� �� ���� �����
		if(!p->next) 
			return 0;
		// ���� ������ �� ����� ��������
		p = p->next;
	}
	// ���� ������� �� ������ - � ����� �� ���� �����
	return 0;
}

// ������� ����� � �������
void insert(char data) {
	// ��� �����
	auto hashed = hash(data);
	// ����� � ��� �������
	auto p = hashtable[hashed];
	// ������ ����� ��� � ���-�������, ������� ����� ��������
	if(!p) {
		hashtable[hashed] = getNew(data);
		return;
	}

	// ��������� ����� ��������.
	while(p) {
		// ���� ����� �������� - ����������� ����������
		if(p->value == data) {
			p->count++;
			break;
		}
		// ���� ��� ���������� �������� � ����� �������� - ������� �����
		if(!p->next) {
			p->next = getNew(data);
			break;
		}

		// ���� ������ �� ����� ��������
		p = p->next;
	}
}

// ����� �������
void print() {
	//�������� ����� ��� �������
	for(int i = 0; i < size; i++) {
		// ���� ������� ������� ���� - ����������
		if(hashtable[i] == nullptr) 
			continue;

		// � ��������� ������, �������� ���
		printf("[%i]: %c : %i\n", i, hashtable[i]->value, hashtable[i]->count);

		// ���� ����� �������� �� ����� - ���� �� ��� � �������� ��� ��������
		auto child = hashtable[i]->next;
		while(child != nullptr) {
			printf("| -> %c: %i\n", child->value, hashtable[i]->count);
			child = child->next;
		}
	}
}

int main() {
	// ������������ �������� ����� - 128 ����.
	char* word = (char*)calloc(128, sizeof(char));
	// ������ ��� �����
	char input;
	printf("Commands: '#' - exit, '+' - add, '&' - print table, '?' - get specific character count\n");
	while(true) {
		printf("input: ");
		std::cin >> input;

		// ����� �� ���������
		if(input == '#')
			break;

		// ����� �� ������������ �����
		if(input == '?') {
			std::cin >> input;
			printf("count: %i\n", lookup(input));
		} 
		// ������ �������
		else if(input == '&') {
			print();
		}

		// ���� �������� � �������
		else if(input == '+') {
			std::cin >> word;
			int i = 0;
			// ��� ��� � �++ ����� ������������� �� \0, ����� ������� ����� ������ ����� �����.
			while(word[i] != '\0') {
				insert(word[i++]);
			}
		} 
	}
}