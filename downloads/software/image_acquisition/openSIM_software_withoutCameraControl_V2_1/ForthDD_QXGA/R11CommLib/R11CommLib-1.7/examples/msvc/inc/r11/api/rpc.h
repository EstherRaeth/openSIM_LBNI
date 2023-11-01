#ifndef _R11_API_RPC_H
#define _R11_API_RPC_H

#define MAINBOARD_TYPE_M175         0x02

#define MAINBOARD_REV_A             0x00

#define DAUGHTERBOARD_TYPE_NONE     0x00
#define DAUGHTERBOARD_TYPE_M118A    0x01
#define DAUGHTERBOARD_TYPE_M118B    0x02

#define DISPLAY_TYPE_NONE           0x00
#define DISPLAY_TYPE_M150           0x03
#define DISPLAY_TYPE_UNKNOWN        0xFF

#define ACT_IMMEDIATE               0x01
#define ACT_SOFTWARE                0x02
#define ACT_HARDWARE                0x04

#ifdef __cplusplus
extern "C" {  
#endif

FDD_RESULT R11_RpcSysGetBoardType(uint8_t *);
FDD_RESULT R11_RpcSysSelectAddr(uint8_t);
FDD_RESULT R11_RpcSysReboot(void);
FDD_RESULT R11_RpcSysGetStoredChecksum(uint16_t, uint32_t *);
FDD_RESULT R11_RpcSysGetCalculatedChecksum(uint16_t, uint32_t *);
FDD_RESULT R11_RpcSysGetBitplaneCount(uint32_t *);
FDD_RESULT R11_RpcSysReloadRepertoire(void);
FDD_RESULT R11_RpcSysGetRepertoireName(char *, uint8_t);
FDD_RESULT R11_RpcSysGetRepertoireUniqueId(char *, uint8_t);
FDD_RESULT R11_RpcSysSaveSettings(void);
FDD_RESULT R11_RpcSysGetDaughterboardType(uint8_t *);
FDD_RESULT R11_RpcSysGetADC(uint8_t, uint16_t *);
FDD_RESULT R11_RpcSysGetBoardID(uint8_t *);
FDD_RESULT R11_RpcSysGetDisplayType(uint8_t *);
FDD_RESULT R11_RpcSysGetDisplayTemp(uint16_t *);
FDD_RESULT R11_RpcSysGetSerialNum(uint32_t *);
FDD_RESULT R11_RpcMicroGetCodeTimestamp(char *, uint8_t);
FDD_RESULT R11_RpcMicroGetCodeVersion(uint16_t *);
FDD_RESULT R11_RpcFlashEraseBlock(uint32_t);
FDD_RESULT R11_RpcFpgaRead(uint8_t, void *, uint8_t);
FDD_RESULT R11_RpcFpgaWrite(uint8_t, const void *, uint8_t);
FDD_RESULT R11_RpcRoGetCount(uint16_t *);
FDD_RESULT R11_RpcRoGetSelected(uint16_t *);
FDD_RESULT R11_RpcRoGetDefault(uint16_t *);
FDD_RESULT R11_RpcRoSetSelected(uint16_t);
FDD_RESULT R11_RpcRoSetDefault(uint16_t);
FDD_RESULT R11_RpcRoGetActivationType(uint8_t *);
FDD_RESULT R11_RpcRoGetActivationState(uint8_t *);
FDD_RESULT R11_RpcRoActivate(void);
FDD_RESULT R11_RpcRoDeactivate(void);
FDD_RESULT R11_RpcRoGetName(uint16_t, char *, uint8_t);
FDD_RESULT R11_RpcRoSetSelectedBlind(uint16_t);
FDD_RESULT R11_RpcLedSet(uint8_t);
FDD_RESULT R11_RpcLedGet(uint8_t *);
FDD_RESULT R11_RpcFlipTpSet(uint8_t);
FDD_RESULT R11_RpcFlipTpGet(uint8_t *);
FDD_RESULT R11_RpcMaintLedSet(BOOL);
FDD_RESULT R11_RpcMaintLedGet(BOOL *);

#ifdef __cplusplus
}
#endif

#endif // _R11_API_RPC_H
