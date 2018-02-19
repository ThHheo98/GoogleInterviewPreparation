/*
 There is a code with a runtime error. We add printf to display the value of a variable and we don't get the runtime error anymore. explain what the reason can be.
 */
/*
 #include <cstdio>
#include <cstring>

int main() {
    const void* res = memchr("Syshsh Pavlik", 'p', 16);
    // printf("%p\n", res);  // uncomment this line and see what happens
    return !*(int*)res;
} 
 * 
 * Concurrency or multithreading issues is my best bet on this..
 * This is an open ended question. 
 */