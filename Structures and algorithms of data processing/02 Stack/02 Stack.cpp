#include <iostream>
// Задаем констнты изначального размера стека и его фактор роста
#define growthFactor 1.75
#define initialSize 5

// Создаем структуру стек с указателем на начало, уровнем заполненности и максимальным размером
struct Stack {
	int* p;
	int cur = 0;
	int max = initialSize;
};

// Выделяем память для стека
void init(struct Stack* stack) {
	stack->p = (int*)malloc(stack->max * sizeof(int));
	if(stack->p == nullptr) exit(-1);
}

// Функция для изменения размера стека, когда достигнуто максимальное число элементов
void resize(struct Stack* stack) {
	if(stack->cur < stack->max) return;
	stack->p = (int*)realloc(stack->p, stack->max * growthFactor * sizeof(int));
	stack->max *= growthFactor;
	if(stack->p == nullptr) exit(-1);
}

// Добавление значения в стек
void push(struct Stack* stack, int value) {
	resize(stack);
	stack->p[stack->cur++] = value;
}

// Удаление значения со стека
int pop(struct Stack* stack) {
	return stack->p[--stack->cur];
};

// Размер стека
int size(struct Stack* stack) {
	return stack->cur;
}

// Вывод стека
void print(struct Stack* stack) {
	for(int i = 0; i < stack->cur; i++) {
		std::cout << stack->p[i] << ' ';
	}
	std::cout << std::endl;
}

// Генерация чисел [-10, 20]
int random() {
	return (rand() % 31) - 10;
}

int main() {
	// Создание стек
	for(int i = 0; i < 5; i++) {
		Stack stack;
		init(&stack);

		// Наполнение стека случайными числами
		int N = 10;
		for(int i = 0; i < N; i++) {
			push(&stack, random());
		}

		// Вывод стека
		std::cout << "Stack: ";
		print(&stack);

		//Нахождение максимального значения
		int max = -10;
		for(int i = 0; i < N; i++) {
			int val = pop(&stack);
			if(val > max) {
				max = val;
			}
		}

		std::cout << "Max: " << max << std::endl << std::endl;
	}
	
	return 0;
}