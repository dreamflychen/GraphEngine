#include "TrinityCommon.h"
#include "asmjit.h"

using namespace asmjit;

static JitRuntime s_runtime;

DLL_EXPORT void* BGetAtom(int32_t width)
{
    CodeHolder code;
    code.init(s_runtime.getCodeInfo());
    return nullptr;
}

DLL_EXPORT void* BGetString()
{
    CodeHolder code;
    code.init(s_runtime.getCodeInfo());
    return nullptr;
}