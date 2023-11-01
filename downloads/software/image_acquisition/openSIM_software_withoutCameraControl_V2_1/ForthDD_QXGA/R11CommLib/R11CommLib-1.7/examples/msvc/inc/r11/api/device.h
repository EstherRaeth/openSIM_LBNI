#ifndef _R11_API_DEVICE_H
#define _R11_API_DEVICE_H

#define FDD_VID                 0x19EC                                  // ForthDD USB VendorID

#define R11_WINUSB_GUID         "54ED7AC9-CC23-4165-BE32-79016BAFB950"  // ForthDD WinUSB GUID for R11 (Required by Windows)
#define R11_WINUSB_PID          0x0503                                  // ForthDD WinUSB PID for R11 (Required by Linux)
#define R11_RS232_BAUDRATE      115200                                  // ForthDD RS-232 Baud rate for R11
#define R11_RS485_BAUDRATE      256000                                  // ForthDD RS-485 Baud rate for R11

#define ATMEL_VID               0x03EB                                  // Atmel USB VendorID
#define ATMEL_SAM_BA_PID        0x6124                                  // Atmel USB ProductID for SAM-BA
#define ATMEL_SAM_BA_BAUDRATE   115200                                  // Atmel SAM-BA Baud rate 

#ifdef __cplusplus
extern "C" {
#endif

FDD_RESULT R11_DevGetProgress(uint8_t *);
FDD_RESULT R11_DevEnumerateWinUSB(DevPtr *, uint16_t *);

#ifdef __cplusplus
}
#endif

#endif // _R11_API_DEVICE_H
