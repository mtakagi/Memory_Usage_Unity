#import <Foundation/Foundation.h>
#import <mach/mach.h>

#ifdef __cplusplus
extern "C" {
#endif
    uint64_t memory_usage();
#ifdef __cplusplus
}
#endif

uint64_t memory_usage() {
    task_vm_info_data_t vmInfo;
    mach_msg_type_number_t count = TASK_VM_INFO_COUNT;
    kern_return_t kernelReturn = task_info(mach_task_self(), TASK_VM_INFO, (task_info_t) &vmInfo, &count);
    
    if(kernelReturn == KERN_SUCCESS)
    {
        return vmInfo.phys_footprint;
    } else {
        return 0;
    }
}
