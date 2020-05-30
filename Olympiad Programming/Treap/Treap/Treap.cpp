#include <iostream>

struct node {
	node* l = nullptr;
	node* r = nullptr;
	int key;
	int prior;
};

node* getNewNode(int key, int prior) {
    node* newnode = new node;
    newnode->key = key;
    newnode->prior = prior;
    return newnode;
}

void split(node* root, int key, node*& l, node*& r) {
    if(root == nullptr)
        l = r = nullptr;
    else if(key < root->key) {
        split(root->l, key, l, root->l);
        r = root;
    } else {
        split(root->r, key, root->r, r);
        l = root;
    }
}

void insert(node*& parent, node* target) {
	if(parent == nullptr)
        parent = target;
    else if(target->prior > parent->prior) {
        split(parent, target->prior, target->l, target->r);
        parent = target;
    } else insert(target->key < parent->key ? parent->l : parent->r, target);
}

void printInorder(struct node* node) {
    if(node == NULL)
        return;

    printInorder(node->l);
    printf("(%i, %i, %i)\n", node->key, node->l == nullptr? 0: node->l->key, node->r == nullptr ? 0 : node->r->key);
    printInorder(node->r);
}

int main() {



    node* root = getNewNode(5, 4);

    insert(root, getNewNode(2, 2));
    insert(root, getNewNode(3, 9));
    insert(root, getNewNode(0, 5));
    insert(root, getNewNode(1, 3));
    insert(root, getNewNode(6, 6));
    insert(root, getNewNode(4, 11));

    printInorder(root);



	std::cout << "Hello World!\n";
}