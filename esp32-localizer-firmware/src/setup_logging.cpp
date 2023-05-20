#include "setup_logging.h"

void printPrefix(Print *_logOutput, int logLevel);

#define LOGGING_PREFIX_SIZE 25

void setupLogging(int logLevel, Print *output)
{
    Log.begin(LOG_LEVEL_VERBOSE, &Serial);
    Log.setPrefix(printPrefix);
}

char timestampBuffer[LOGGING_PREFIX_SIZE];

void printPrefix(Print *_logOutput, int logLevel)
{
    snprintf(timestampBuffer, 25, "%10dms:", millis());
    _logOutput->print(timestampBuffer);
}