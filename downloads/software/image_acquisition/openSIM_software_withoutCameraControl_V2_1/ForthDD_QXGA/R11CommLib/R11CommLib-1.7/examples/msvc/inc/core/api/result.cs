// This file is intended to be used:
//      as a header, by the C compiler, and
//      as source code, by the C# compiler.
// It has the extension '.cs' because the C# compiler insists on that,
// while the C compiler doesn't care about the extensions of #include files.
// The reason for defining the enum in one shared file rather than one for
// each language is to ensure that the C and C# versions stay in step even if
// the enum values change.

#if __LINE__
#define public
    typedef enum
#else
namespace ForthDD.Comm.Binding {
    public enum FDD_RESULT
#endif

{
    FDD_SUCCESS,                 // 0x00

    FDD_MEM_INDEX_OUT_OF_BOUNDS, // 0x01
    FDD_MEM_NULL_POINTER,        // 0x02
    FDD_MEM_ALLOC_FAILED,        // 0x03

    FDD_DEV_SET_TIMEOUT_FAILED,  // 0x04
    FDD_DEV_SET_BAUDRATE_FAILED, // 0x05
    FDD_DEV_OPEN_FAILED,         // 0x06
    FDD_DEV_NOT_OPEN,            // 0x07
    FDD_DEV_ALREADY_OPEN,        // 0x08
    FDD_DEV_NOT_FOUND,           // 0x09
    FDD_DEV_ACCESS_DENIED,       // 0x0A
    FDD_DEV_READ_FAILED,         // 0x0B
    FDD_DEV_WRITE_FAILED,        // 0x0C
    FDD_DEV_TIMEOUT,             // 0x0D
    FDD_DEV_RESYNC_FAILED,       // 0x0E

    FDD_SLAVE_INVALID_PACKET,    // 0x0F
    FDD_SLAVE_UNEXPECTED_PACKET, // 0x10
    FDD_SLAVE_ERROR,             // 0x11
    FDD_SLAVE_EXCEPTION,         // 0x12
} 

#if __LINE__
#undef public
    FDD_RESULT;
#else
}
#endif
