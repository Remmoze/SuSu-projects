#include <iostream>

struct Node {
	int value;
	Node* left = nullptr;
	Node* right = nullptr;
	Node* parent = nullptr;
};

void insert(Node* root, Node* node) {
	if(root->left && root->value > node->value)
		return insert(root->left, node);
	if(root->right && root->value < node->value)
		return insert(root->right, node);
	if(root->value == node->value)
		return;
	if(root->value > node->value)
		root->left = node;
	else root->right = node;
	node->parent = root;
}

int size(Node* root) {
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

int count(Node* node) {
	int sum = 1;
	if(node->left) sum += count(node->left);
	if(node->right) sum += count(node->right);
	return sum;
}

void traversal(Node* node) {//in-order
	if(node->left) traversal(node->left);
	printf("%i\n", node->value);
	if(node->right) traversal(node->right);
}

void leaves(Node* node) {
	if(node->left) leaves(node->left);
	if(!node->left && !node->right)
		printf("%i\n", node->value);
	if(node->right) leaves(node->right);
}

int main() {
	Node* root = nullptr;

	int input;
	while(true) {
		std::cin >> input;
		if(input == 0)
			break;

		if(!root) {
			root = new Node;
			root->value = input;
		} else {
			Node* node = new Node;
			node->value = input;
			insert(root, node);
		}
	}
	leaves(root);
	//std::cout << count(root) << std::endl;
}