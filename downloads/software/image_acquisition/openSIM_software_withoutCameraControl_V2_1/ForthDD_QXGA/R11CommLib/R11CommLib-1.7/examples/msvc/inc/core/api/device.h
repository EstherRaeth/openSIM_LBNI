#ifndef _CORE_API_DEVICE_H
#define _CORE_API_DEVICE_H

#ifdef __cplusplus
extern "C" {  
#endif

typedef struct Dev
{
    char *id;
    struct Dev *next;
} Dev, *DevPtr;

FDD_RESULT FDD_DevEnumerateRS232(uint16_t, uint16_t, DevPtr *, uint16_t *);
FDD_RESULT FDD_DevEnumerateComPorts(DevPtr *devList, uint16_t *devCount);
FDD_RESULT FDD_DevEnumerateHID(uint16_t, uint16_t, DevPtr *, uint16_t *);
FDD_RESULT FDD_DevEnumerateWinUSB(const char *, DevPtr *, uint16_t *);
FDD_RESULT FDD_DevGetFirst(char **);
FDD_RESULT FDD_DevGetNext(char **);
FDD_RESULT FDD_DevOpenRS232(const char *, uint16_t, uint32_t, BOOL);
FDD_RESULT FDD_DevOpenComPort(const char *, uint16_t, uint32_t, BOOL);
FDD_RESULT FDD_DevOpenHID(const char *, uint16_t);
FDD_RESULT FDD_DevOpenWinUSB(const char *, uint16_t);
FDD_RESULT FDD_DevSetTimeout(uint16_t);
FDD_RESULT FDD_DevGetTimeout(uint16_t *);
FDD_RESULT FDD_DevClose(void);

#ifdef __cplusplus
}
#endif

#endif // _CORE_API_DEVICE_H
