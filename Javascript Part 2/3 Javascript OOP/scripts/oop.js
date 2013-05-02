var vehicles = (function () {
    'use strict';

    var AfterBurnerSwitchState = Object.freeze({
        'OFF': 0,
        'ON': 1
    });

    var SpinDirection = Object.freeze({
        'CLOCKWISE': 0,
        'COUNTER_CLOCKWISE': 1
    });

    var AmphibianVehicleMode = Object.freeze({
        'ON_EARTH': 0,
        'IN_WATER' : 1
    });

    Function.prototype.inherits = function (parent) {
        this.prototype = new parent();
        this.prototype.constructor = parent;
    }

    Function.prototype.extend = function (parent) {
        for (var i = 1; i < arguments.length; i++) {
            var name = arguments[i];
            this.prototype[name] = parent.prototype[name];
        }

        return this;
    }

    var PropulsionUnit = function () {
    }

    PropulsionUnit.prototype.Accelerate = function () {
        // this is more of an assertion, becase the PropulsionUnit.Accelerate() method
        // is private:
        throw new Error('The method PropulsionUnit.Accelerate() cannot be called, because it is abstract!');
    }

    var Wheel = function (radius) {
        if (!radius || radius < 0) {
            throw new Error('Wheel radius, which is larger than 0, must be specified!');
        }

        this.radius = radius;
    }

    Wheel.inherits(PropulsionUnit);

    Wheel.prototype.Accelerate = function () {
        return parseFloat(2 * Math.PI * this.radius);
    }

    var PropellingNozzle = function (power) {
        if (typeof power === 'undefined') {
            throw new Error('Power must be specified!');
        }

        this.power = power;
        this.afterburnerSwitch = AfterBurnerSwitchState.OFF;
    }

    PropellingNozzle.inherits(PropulsionUnit);

    PropellingNozzle.prototype.Accelerate = function () {
        if (this.afterburnerSwitch == AfterBurnerSwitchState.ON) {
            return this.power * 2;
        } else {
            return this.power;
        }
    }

    PropellingNozzle.prototype.toggleAfterburner = function () {
        if (this.afterburnerSwitch == AfterBurnerSwitchState.ON) {
            this.afterburnerSwitch = AfterBurnerSwitchState.OFF;
        } else {
            this.afterburnerSwitch = AfterBurnerSwitchState.ON;
        }
    }

    var Propeller = function (numberOfFins, spinDirection) {
        if (!numberOfFins || numberOfFins < 0) {
            throw new Error('A number of fins, which is larger than 0, must be specified!');
        }

        if (typeof spinDirection === 'undefined') {
            throw new Error('A spin direction must be specified!');
        }

        this.numberOfFins = numberOfFins;
        this.spinDirection = spinDirection;
    }

    Propeller.inherits(PropulsionUnit);

    Propeller.prototype.Accelerate = function () {
        if (this.spinDirection == SpinDirection.CLOCKWISE) {
            return this.numberOfFins;
        } else {
            return -this.numberOfFins;
        }
    }

    Propeller.prototype.toggleSpinDirection = function() {
        if (this.spinDirection === SpinDirection.CLOCKWISE) {
            this.spinDirection = SpinDirection.COUNTER_CLOCKWISE;
        } else {
            this.spinDirection = SpinDirection.CLOCKWISE;
        }
    }

    Propeller.prototype.getSpinDirection = function () {
        return this.spinDirection;
    }

    var Vehicle = function (power, propulsionUnits) {
        this.power = power;
        this.propulsionUnits = propulsionUnits;
    }

    Vehicle.prototype.getAcceleration = function () {
    }

    var EarthVehicle = function (wheelRadius) {
        this.wheels = new Array();
        for (var i = 0; i < 4; i++) {
            this.wheels.push(new Wheel(wheelRadius));
        }
    }

    EarthVehicle.inherits(Vehicle);

    EarthVehicle.prototype.getAcceleration = function () {
        var acceleration = 0;
        for (var i = 0; i < this.wheels.length; i++) {
            acceleration += this.wheels[i].Accelerate();
        }

        return acceleration;
    }

    var AirVehicle = function (propellingNozzlePower) {
        this.propellingNozzle = new PropellingNozzle(propellingNozzlePower);
    }

    AirVehicle.inherits(Vehicle);

    AirVehicle.prototype.getAcceleration = function () {
        return this.propellingNozzle.Accelerate();
    }

    // a method for toggling the afterburner on/off
    AirVehicle.prototype.toggleAfterburner = function () {
        this.propellingNozzle.toggleAfterburner();
    }

    // a method, which returns 1 if the afterburner is on and
    // 0 if it is off.
    AirVehicle.prototype.getAfterburnerState = function () {
        return this.propellingNozzle.afterburnerSwitch;
    }

    var WaterVehicle = function (propellersCount, numberOfFins, spinDirection) {
        if (propellersCount < 0 || !propellersCount) {
            throw new Error('A number of propellers, which is larger than 0, must be specified!');
        }

        this.propellers = new Array();
        for (var i = 0; i < propellersCount; i++) {
            propellersCount.push(new Propeller(numberOfFins, spinDirection));
        }
    }

    WaterVehicle.inherits(Vehicle);

    WaterVehicle.prototype.getAcceleration = function () {
        var acceleration = 0;

        for (var i = 0; i < this.propellers.length; i++) {
            acceleration += this.propellers[i].Accelerate();
        }

        return acceleration;
    }

    WaterVehicle.prototype.toggleSpinDirection = function () {
        for (var i = 0; i < this.propellers.length; i++) {
            this.propellers[i].toggleSpinDirection();
        }
    }

    WaterVehicle.prototype.getSpinDirection = function () {
        return this.propellers[0].getSpinDirection();
    }

    var AmphibiousVehicle = function (wheelRadius, propellerCount, propellerNumberOfFins, propellerSpinDirection, vehicleMode) {
        this.vehicleMode = vehicleMode;

    }

    AmphibiousVehicle.inherits(Vehicle);

    return {
        AfterBurnerSwitchState: AfterBurnerSwitchState,
        SpinDirection: SpinDirection,
        Wheel: Wheel,
        PropellingNozzle: PropellingNozzle,
        Propeller: Propeller,
        EarthVehicle: EarthVehicle,
        AirVehicle: AirVehicle,
        WaterVehicle: WaterVehicle
    }
})();