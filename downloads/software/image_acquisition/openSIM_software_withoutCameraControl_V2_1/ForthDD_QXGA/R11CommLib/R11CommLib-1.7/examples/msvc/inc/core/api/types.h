#ifndef _CORE_API_TYPES_H
#define _CORE_API_TYPES_H

#ifndef BOOL
#define BOOL uint8_t
#endif

#ifndef FALSE
#define FALSE   0
#endif

#ifndef TRUE
#define TRUE    1
#endif

#ifndef NULL
#ifdef __cplusplus
#define NULL    0
#else
#define NULL    ((void *)0)
#endif
#endif

#include "result.cs"

#endif // _CORE_API_TYPES_H
