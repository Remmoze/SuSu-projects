#include <iostream>
#define size 16

struct node {
	char value;
	int count;
	node* next = nullptr;
};

// Хеш-функция "Fowler–Noll–Vo". Обеспечивает равномерное распределение данных
// в хеш-таблице с минимальным количеством коллизий.
static const unsigned int FNV_PRIME = 16777619u;
static const unsigned int OFFSET_BASIS = 2166136261u;
int hash(char data) {
	unsigned int hash = OFFSET_BASIS;
	hash ^= data;
	hash *= FNV_PRIME;
	return hash % size;
}

// Определение хеш-таблицы
node* hashtable[size];
// Функция для определения нового элемента в хеш-таблицу
node* getNew(char data) {
	node* elem = new node;
	elem->value = data;
	elem->count = 1;
	return elem;
}

// Поиск буквы в хеш-таблице
int lookup(char data) {
	// берем элемент из хеш-таблицы
	auto p = hashtable[hash(data)];
	while(p) {
		// найдена буква, возращается количество
		if(data == p->value)
			return p->count;
		//если нет следующего элемента - в слове не было буквы
		if(!p->next) 
			return 0;
		// идем дальше по ветке коллизии
		p = p->next;
	}
	// если элемент не найден - в слове не было буквы
	return 0;
}

// вставка буквы в таблицу
void insert(char data) {
	// Хеш буквы
	auto hashed = hash(data);
	// Место в хеш таблице
	auto p = hashtable[hashed];
	// Данной буквы нет в хеш-таблице, создаем новое значение
	if(!p) {
		hashtable[hashed] = getNew(data);
		return;
	}

	// Проверяем ветку коллизий.
	while(p) {
		// Если нашли значение - увеличиваем количество
		if(p->value == data) {
			p->count++;
			break;
		}
		// Если нет следующего элемента в ветке коллизий - создаем новое
		if(!p->next) {
			p->next = getNew(data);
			break;
		}

		// Идем дальше по ветке коллизий
		p = p->next;
	}
}

// вывод таблицы
void print() {
	//проходим через всю таблицу
	for(int i = 0; i < size; i++) {
		// если элемент таблицы пуст - пропускаем
		if(hashtable[i] == nullptr) 
			continue;

		// в противном случае, печатаем его
		printf("[%i]: %c : %i\n", i, hashtable[i]->value, hashtable[i]->count);

		// если ветка коллизии не пуста - идем по ней и печатаем все значения
		auto child = hashtable[i]->next;
		while(child != nullptr) {
			printf("| -> %c: %i\n", child->value, hashtable[i]->count);
			child = child->next;
		}
	}
}

int main() {
	// максимальная величина слова - 128 букв.
	char* word = (char*)calloc(128, sizeof(char));
	// символ для ввода
	char input;
	printf("Commands: # - exit, + - add, % - print table, ? - get specific character count\n");
	while(true) {
		printf("input: ");
		std::cin >> input;

		// выход из программы
		if(input == '#')
			break;

		// поиск по определенной букве
		if(input == '?') {
			std::cin >> input;
			printf("count: %i\n", lookup(input));
		} 
		// печать таблицы
		else if(input == '%') {
			print();
		}

		// ввод значения в таблицу
		else if(input == '+') {
			std::cin >> word;
			int i = 0;
			// так как в с++ слово заканчивается на \0, таким образом можно узнать конец слова.
			while(word[i] != '\0') {
				insert(word[i++]);
			}
		} 
	}
}