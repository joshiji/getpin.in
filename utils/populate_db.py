
import os
import sqlite3
import getopt
import sys
from uuid import uuid4

(
    OFFICE_NAME,
    PINCODE,
    OFFICE_TYPE,
    DELIVERY_STATUS,
    DIVISION_NAME,
    REGION_NAME,
    CIRCLE_NAME,
    TALUK,
    DISTRICT_NAME,
    STATE_NAME,
    TELEPHONE,
    RELATED_SUBOFFICE,
    RELATED_HEADOFFICE,
    LOGITUDE,
    LATITUDE
    ) = range(15)

(
    BO,
    BO_AW_HO,
    HO,
    SO
    ) = range(4)

(
    DELIVERY,
    NON_DELIVERY
    ) = range(2)

def print_info(msg):
    print "[Info]" + msg

def print_warning(msg):
    print "[Warning]" + msg

def print_error(msg):
    print "[Error]" + msg

def parse_csv(csv_file):

    class State(object):
        state_id = ""
        state_name = ""

    class Office(object):
        office_id = ""
        office_name = ""

    class Country(object):
        country_id = ""
        country_name = ""

    class District(object):
        district_id = ""
        district_name = ""
        state_id = ""

    class Division(object):
        division_id = ""
        division_name = ""
        region_id = ""

    class Region(object):
        region_id = ""
        region_name = ""

    class Taluk(object):
        taluk_id = ""
        taluk_name = ""
        district_id = ""

    class PinCode(object):
        pin_code_id = ""
        pin_code_num = ""
        country_id = ""

    class PostOffice(object):
        post_office_id = ""
        office_id = ""
        pin_code_id = ""
        office_type = BO
        office_id = ""
        delivery_status = DELIVERY
        division_id = ""
        region_id = ""
        circle_id = ""
        taluk_id = ""
        district_id = ""
        state_id = ""
        phone = ""
        related_suboffice_id = ""
        related_headoffice_id = ""
        longitude = ""
        latitude = ""


    states = []
    offices = []
    coutries = []
    districts = []
    divisions = []
    regions = []
    taluks = []
    pin_codes = []
    post_offices = []

    state_names = []
    office_names = []
    district_names = []
    division_names = []
    region_names = []
    taluk_names = []
    pin_code_numbers = []

    country = Country()
    country.country_id = str(uuid4())
    country.country_name = "India"

    fh = open(csv_file)
    header_done = False

    for i, line in enumerate(fh):
        if not header_done:
            header_done = True
            pass
        else:
            splitted_line = line.strip().split(',')
            office_name = splitted_line[OFFICE_NAME]
            pin_code_number = splitted_line[PINCODE]
            office_type = splitted_line[OFFICE_TYPE]
            delivery_status = splitted_line[DELIVERY_STATUS]
            division_name = splitted_line[DIVISION_NAME]
            region_name = splitted_line[REGION_NAME]
            circle_name = splitted_line[CIRCLE_NAME]
            taluk_name = splitted_line[TALUK]
            district_name = splitted_line[DISTRICT_NAME]
            state_name = splitted_line[STATE_NAME]
            telephone = splitted_line[TELEPHONE]
            related_suboffice = splitted_line[RELATED_SUBOFFICE]
            related_headoffice = splitted_line[RELATED_HEADOFFICE]
            longitude = splitted_line[LOGITUDE]
            latitude = splitted_line[LATITUDE]
            #print_info("Processing " + state_name)
            if state_name.upper() not in state_names:
                state = State()
                state.state_id = str(uuid4())
                state.state_name = state_name.upper()
                states.append(state)
                state_names.append(state_name.upper())

            if district_name.upper() not in district_names:
                district = District()
                district.district_id = str(uuid4())
                district.district_name = district_name.upper()
                state = [s for s in states if s.state_name == state_name.upper()]
                if len(state) == 1:
                    district.state_id = state[0].state_id
                    districts.append(district)
                    district_names.append(district_name.upper())
                else:
                    print_error("Some error occurred for row " + str(i+1))
                    print_warning("Skipping this row")
                    pass


            if office_name.upper() not in office_names:
               office = Office()
               office.office_id = str(uuid4())
               office.office_name = office_name.upper()
               offices.append(office)
               office_names.append(office_name.upper())

            if region_name.upper() not in region_names:
                region = Region()
                region.region_id = str(uuid4())
                region.region_name = region_name.upper()
                regions.append(region)
                region_names.append(region_name.upper())

            if division_name.upper() not in division_names:
                division = Division()
                division.division_id = str(uuid4())
                division.division_name = division_name.upper()
                region = [r for r in regions if r.region_name == region_name.upper()]
                if len(region) == 1:
                    division.region_id = region[0].region_id
                    divisions.append(division)
                    division_names.append(division_name.upper())
                else:
                    print_error("Some error occurred in row " + str(i+1))
                    pass

            if taluk_name not in taluk_names:
                taluk = Taluk()
                taluk.taluk_id = str(uuid4())
                taluk.taluk_name = taluk_name.upper()
                district = [d for d in districts if d.district_name == district_name.upper()]
                if len(district) == 1:
                    taluk.district_id = district[0].district_id
                    taluks.append(taluk)
                    taluk_names.append(taluk_name.upper())
                else:
                    print_error("Error occurred in row " + str(i+1))
                    pass

            if pin_code_number not in pin_code_numbers:
                pin_code = PinCode()
                pin_code.pin_code_id = str(uuid4())
                pin_code.pin_code_number = pin_code_number
                pin_code.country_id = country.country_id
                pin_codes.append(pin_code)
                pin_code_numbers.append(pin_code_number)


            post_office = PostOffice()
            post_office.post_office_id = str(uuid4())
            post_office.post_office_name = post_office_name

            pin_code = [pc for pc in pin_codes if pc.pin_code_number == pin_code_number]
            if len(pin_code) == 1:
                post_office.pin_code_id = pin_code[0].pin_code_id
            else:
                print_error("Error in pin code for row " + str(i+1))o
                pass

            if office_type.strip() == "B.O":
                post_office.office_type = BO
            elif office_type.strip() == "H.O":
                post_office.office_type = HO
            elif office_type.strip() == "S.O":
                post_office.office_type = SO
            else:
                post_office.office_type = BO_AW_HO

            if i == 2000:
                break



def main(argv):
    csv_file = ""
    db_file = ""

    opts, args = getopt.getopt(argv, 'c:d:')

    for opt, arg in opts:
        if opt == "-c":
            csv_file = arg
        elif opt == "-d":
            db_file = arg

    print_info("CSV File is " + csv_file)
    print_info("DB File is " + db_file)

    csv_data = parse_csv(csv_file)

if __name__ == "__main__":
    main(sys.argv[1:])


