#include <iostream>
#include <string>

struct Task {
	bool type; // 0 - cut/join, 1 - ask
	int a;
	int b;
};

int* parents;
Task** tasks;
char* answers;

int find_set(int v) {
	if(parents[v] == v)
		return v;
	return parents[v] = find_set(parents[v]);
}

void union_sets(int a, int b) {
	a = find_set(a);
	b = find_set(b);
	if(a == b) return;
	parents[b] = a;
}

int main() {
	int n, waste, k;
	std::cin >> n; // nodes
	n++;
	parents = new int[n+1];
	for(int i = 0; i < n; i++)
		parents[i] = i;

	// edges (discrd, they are useless lol)
	std::cin >> n; 
	std::cin >> k;
	k++;
	while(n--) {
		std::cin >> waste;
		std::cin >> waste;
	}

	tasks = new Task*[k];
	answers = new char[k];

	std::string input;
	for(int i = 1; i < k; i++) {
		std::cin >> input;
		Task* task = new Task();
		std::cin >> task->a;
		std::cin >> task->b;

		task->type = input.compare("cut") != 0;
		tasks[i] = task;
	}
	for(int i = k-1; i > 0; i--) {
		if(tasks[i]->type) {
			answers[i] = find_set(tasks[i]->a) == find_set(tasks[i]->b) ? 'y' : 'n';
		} else {
			union_sets(tasks[i]->a, tasks[i]->b);
		}

		//printf("%s %i %i\n", tasks[i]->type ? "ask" : "cut", tasks[i]->a, tasks[i]->b);
	}

	for(int i = 0; i < k; i++) {
		if(answers[i] == 'n')
			printf("NO\n");
		if(answers[i] == 'y')
			printf("YES\n");
	}

}