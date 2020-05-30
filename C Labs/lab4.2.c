#include <stdio.h>
#include <stdlib.h>
#include <string.h>

struct Student {
	char* name;
	int _class;
	int marks[5];
	struct Student* prev;
	struct Student* next;
};

struct Student* insert(struct Student* first, struct Student* target) {
	target->next = NULL;
	target->prev = NULL;
	if(first == NULL)
		return target; //set first ever element

	if(first->_class > target->_class) {
		target->next = first;
		first->prev = target;
		return target; //replace first element
	}
	if(first->next == NULL) { 
		first->next = target;
		target->prev = first;
		return first; //place next to first element.
	}
	struct Student* current = first->next;
	while(1) {
		if(current->_class > target->_class) {
			current->prev->next = target;
			target->prev = current->prev;
			target->next = current;
			current->prev = target;
			return first; //place element before a higher one
		}
		if(current->next == NULL) {
			current->next = target;
			target->prev = current;
			return first; //end of list, place as last one
		}
		current = current->next;
	}
}

char* getInitials(struct Student student) {
	int space1 = (int)(strchr(student.name, ' ') - student.name);
	int space2 = (int)(strchr(student.name + space1 + 2, ' ') - student.name);

	char* initials = (char*)calloc(space1 + 6, sizeof(char));
	strncpy(initials, student.name, space1 + 2);

	initials[space1 + 2] = initials[space1 + 4] = '.';
	initials[space1 + 3] = student.name[space2 + 1];
	initials[space1 + 5] = '\0';
	return initials;
}

float avarage(struct Student student) {
	float sum = 0;
	for(int i = 0; i < 5; i++)
		sum += student.marks[i];
	return sum / 5;
}

int main(int argc, char* argv[]) {
	printf("~~-Students managment system-~~\nWrite '-' in name field to stop the input.\n");

	struct Student* first = NULL;
	char buf[100];
	int size;

	for(size = 0; size < 10; size++) {

		struct Student* newcomer = malloc(sizeof(struct Student));

		printf("\n|%i. ", size + 1);
		printf("\n|------ Name: ");

		fgets(buf, 100, stdin);
		if(buf[0] == '-') break;
		if(buf[strlen(buf) - 1] == '\n') buf[strlen(buf) - 1] = '\0';
		newcomer->name = calloc(strlen(buf) + 1, sizeof(char));
		strcpy(newcomer->name, buf);

		printf("|------ Class: ");
		scanf("%i", &(newcomer->_class));

		printf("|------ Marks: ");
		for(int j = 0; j < 5; j++)
			scanf("%i", &(newcomer->marks[j]));

		getchar(); //ignore last newline

		first = insert(first, newcomer);
	}

	printf("\nStudents with avarage mark higher than 4.0:\n");
	char found = 0;
	struct Student* current = first;
	while(current != NULL) {
		if(avarage(*current) > 4.0f) {
			found = 1;
			printf("(%i) %s\n", (*current)._class, getInitials(*current));
		}
		current = current->next;
	}
	if(!found)
		printf("No Students were found.\n");

	return 0;
}