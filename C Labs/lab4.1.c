#include <stdio.h>
#include <string.h>

struct Student {
	char* name;
	int _class;
	int marks[5];
};

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

inline int classSort(void const* a, void const* b) {
	return ((struct Student*)a)->_class - ((struct Student*)b)->_class;
}

int main(int argc, char* argv[]) {
	printf("~~-Students managment system-~~\nWrite '-' in name field to stop the input.\n");

	struct Student* students = calloc(10, sizeof(struct Student));
	char buf[100];
	int size;

	for(size = 0; size < 10; size++) {
		printf("\n|%i. ", size + 1);
		printf("\n|------ Name: ");

		fgets(buf, 100, stdin);
		if(buf[0] == '-') break;
		if(buf[strlen(buf) - 1] == '\n') buf[strlen(buf) - 1] = '\0';
		students[size].name = calloc(strlen(buf) + 1, sizeof(char));
		strcpy(students[size].name, buf);

		printf("|------ Class: ");
		scanf("%i", &(students[size]._class));

		printf("|------ Marks: ");
		for(int j = 0; j < 5; j++)
			scanf("%i", &(students[size].marks[j]));

		getchar(); //ignore last newline
	}

	qsort(students, size, sizeof(struct Student), classSort);

	printf("\nStudents with avarage mark higher than 4.0:\n");
	char found = 0;
	for(int i = 0; i < size; i++) {
		if(avarage(students[i]) > 4.0f) {
			found = 1;
			printf("(%i) %s\n", students[i]._class, getInitials(students[i]));
		}
	}
	if(!found)
		printf("No Students were found.\n");

	return 0;
}