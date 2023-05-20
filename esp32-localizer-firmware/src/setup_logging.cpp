#include "setup_logging.h"

void printPrefix(Print *_logOutput, int logLevel);

void setupLogging(int logLevel, Print *output)
{
    Log.begin(LOG_LEVEL_VERBOSE, &Serial);
    Log.setPrefix(printPrefix);
}

char timestampBuffer[25];

void printPrefix(Print *_logOutput, int logLevel)
{
    snprintf(timestampBuffer, 25, "%10dms:", millis());
    _logOutput->print(timestampBuffer);
}