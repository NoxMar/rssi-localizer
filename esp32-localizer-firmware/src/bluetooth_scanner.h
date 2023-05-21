#ifndef BLUETOOTH_SCANNER_H
#define BLUETOOTH_SCANNER_H

#include <BLEDevice.h>

class RssiScanner
{
private:
    int scanDurationsSeconds;
    bool activeMode;

public:
    void scan();
    RssiScanner(int scanDurationSeconds, bool activeMode);
};

#endif /* BLUETOOTH_SCANNER_H */