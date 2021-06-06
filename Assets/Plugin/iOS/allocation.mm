#import <Foundation/Foundation.h>

#ifdef __cplusplus
extern "C" {
	void allocation();
	void deallocation();
}
#endif

struct LinkedList {
	void *current;
    LinkedList *prev;
	LinkedList *next;
};

static struct LinkedList *list = NULL;

void add(void *ptr) {
    if (list == NULL) {
        list = (LinkedList *)malloc(sizeof(LinkedList));
        list->current = ptr;
        list->prev = NULL;
        list->next = NULL;
    } else {
        LinkedList *next = (LinkedList *)malloc(sizeof(LinkedList));
        next->current = ptr;
        next->prev = list;
        next->next = NULL;
        list->next = next;
        list = next;
    }
}


void allocation() {
	void* ptr = malloc(1024 * 1024 * 100);
	bzero(ptr, 1024 * 1024 * 100);
	add(ptr);
}

void deallocation() {
    if (list != NULL) {
        free(list->current);
        if (list->prev != NULL) {
            list = list->prev;
            free(list->next);
            list->next = NULL;
        } else {
            free(list);
            list = NULL;
        }
    }
}
