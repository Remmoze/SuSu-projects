#include <iostream>

/*

Not a final version. This is the solution to the test, not the implementation of the structure yet.

*/

struct node {
	int value;
	node* left = nullptr;
	node* right = nullptr;
	node* parent = nullptr;
};

void insert(node* root, node* nod) {
	if(root->left && root->value > nod->value)
		return insert(root->left, nod);
	if(root->right && root->value < nod->value)
		return insert(root->right, nod);
	if(root->value == nod->value)
		return;
	if(root->value > nod->value)
		root->left = nod;
	else root->right = nod;
	nod->parent = root;
}

int size(node* root) {
	if(!root) return 0;
	if(!root->left && !root->right)
		return 1;
	if(root->left && !root->right)
		return size(root->left) + 1;
	if(root->right && !root->left)
		return size(root->right) + 1;

	int lsize = size(root->left) + 1;
	int rsize = size(root->right) + 1;
	if(lsize > rsize)
		return lsize;
	return rsize;
}

int main() {
	node* root = nullptr;

	int input;
	while(true) {
		std::cin >> input;
		if(input == 0)
			break;

		if(!root) {
			root = new node;
			root->value = input;
		} else {
			node* nod = new node;
			nod->value = input;
			insert(root, nod);
		}
	}
	std::cout << size(root) << std::endl;
}