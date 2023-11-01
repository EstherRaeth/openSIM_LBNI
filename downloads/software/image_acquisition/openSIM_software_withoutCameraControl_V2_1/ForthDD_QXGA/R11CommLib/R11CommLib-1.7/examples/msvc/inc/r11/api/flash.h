#ifndef _R11_API_FLASH_H
#define _R11_API_FLASH_H

// External Flash definitions
#define EF_IMAGE_BASE           0x01000000
#define EF_IMAGE_END            0x0102FFFF
#define EF_USER_BASE            0x01031000
#define EF_USER_END             0x0103FDFF

#define EF_PAGE_SIZE            2048        // Bytes
#define EF_PAGES_PER_BLOCK      64

#define IF_PAGE_SIZE            256         // Bytes
#define IF_PAGES_PER_BLOCK      1

#ifdef __cplusplus
extern "C" {
#endif

FDD_RESULT R11_FlashRead(void *, uint16_t, uint16_t);
FDD_RESULT R11_FlashWrite(const void *, uint16_t, uint16_t);
FDD_RESULT R11_FlashBurn(uint32_t);
FDD_RESULT R11_FlashGrab(uint32_t);

#ifdef __cplusplus
}
#endif

#endif // _R11_API_FLASH_H
