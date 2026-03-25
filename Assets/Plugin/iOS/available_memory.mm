#import <os/proc.h>

#ifdef __cplusplus
extern "C" {
#endif
   size_t available_memory();
#ifdef __cplusplus
}
#endif

size_t available_memory() {
	return os_proc_available_memory();
}